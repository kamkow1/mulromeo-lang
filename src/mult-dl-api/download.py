import sys
import youtube_dl
import glob
import os
import contextlib

# silence stdout from external modules
with contextlib.redirect_stdout(None):
    url = sys.argv[1]
    file_format = sys.argv[2]

    video_info = youtube_dl.YoutubeDL().extract_info(url=url, download=False)
    file_name = f"cache/{video_info['title']}.{file_format}"
    options={
        "format"    : "bestaudio/best",
        "keepvideo" : False,
        "outtmpl"   : file_name,
    }

    with youtube_dl.YoutubeDL(options) as ydl:
        # clear cache
        ydl.cache.remove()
        ydl.download([video_info["webpage_url"]])

    # read cache
    media = open(file_name, "rb").read()

print(media)

# clear cache
#files = glob.glob("cache/")
#for f in files:
#    os.remove(f)