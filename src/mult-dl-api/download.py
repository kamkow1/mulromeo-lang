import sys
import youtube_dl
import os
import contextlib
import shutil

# silence stdout from external modules
with contextlib.redirect_stdout(None):
    url = sys.argv[1]
    file_format = sys.argv[2]

    video_info = youtube_dl.YoutubeDL().extract_info(url=url, download=False)
    title = video_info['title'].replace(" ", "_")
    file_name = f"cache/{title}.{file_format}"
    options={
        "format"    : "bestaudio/best",
        "keepvideo" : False,
        "outtmpl"   : file_name,
    }

    with youtube_dl.YoutubeDL(options) as ydl:
        # clear cache
        ydl.cache.remove()
        ydl.download([video_info["webpage_url"]])

# return cached file name
print(file_name)