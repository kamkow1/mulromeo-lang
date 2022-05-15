import sys
import youtube_dl

url = sys.argv[1]
print(url)

video_info = youtube_dl.YoutubeDL().extract_info(url = url, download=False)
filename = f"temp/{video_info['title']}.mp3"
options={
    'format':'bestaudio/best',
    'keepvideo':False,
    'outtmpl':filename,
}

with youtube_dl.YoutubeDL(options) as ydl:
    # clear cache
    ydl.cache.remove()
    ydl.download([video_info['webpage_url']])

