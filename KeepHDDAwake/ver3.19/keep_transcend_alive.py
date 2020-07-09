"""논리 드라이브의 슬립상태 전환 방지"""

import ctypes
import itertools
import string
import os
import time


def main():
    # 슬립 상태를 방지할 논리 드라이브 레터의 리스트
    tgt_drives = ["E"]
    # 다시 쓰기 시간 간격(초):
    # 슬립 상태를 방지하기 위해 일정 기간 간격으로 해당 디스크에 쓰기를 반복
    rewrite_intvl = 20
    while True:
        drives = get_drives()
        for td in tgt_drives:
            if td in drives:
                touch_drive(td)
        time.sleep(rewrite_intvl)


def touch_drive(drive_letter: str):
    """특정 드라이브에 임시 파일을 쓰고 삭제합니다.

    Args:
        drive_letter: 드라이브의 문자(예: 'E')
    """
    time_stmp = int(time.time())
    tgt_path = os.path.join(f"{drive_letter}:/", f"KeepHddAwake-{time_stmp}.txt")
    with open(tgt_path, 'w') as f:
        f.write(str(time_stmp))
    if os.path.isfile(tgt_path):
        os.remove(tgt_path)


def get_drives():
    """시스템 논리 드라이브 레터의 튜플을 반환합니다."""

    drive_bitmask = ctypes.cdll.kernel32.GetLogicalDrives()
    drives = tuple(
        itertools.compress(
            string.ascii_uppercase,
            map(lambda x: ord(x) - ord('0'), bin(drive_bitmask)[:1:-1])
        )
    )
    return drives


if __name__ == '__main__':
    main()
