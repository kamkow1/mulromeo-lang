const app = require('express')()
const port = 8080

const { spawn } = require('child_process')

app.get('/api/get-video', (req, res) => {

    const target = req.query.target
    const format = req.query.format

    const downloadProcess = spawn('python', ['./download.py', target, format])

    downloadProcess.stdout.on('data', data => {
        const fileName = data.toString().trim()
        console.log(`sending file: ${fileName}`)

        res.download(`./${fileName}`)
        clearCache()

        downloadProcess.stdout.removeAllListeners('data')
    })

})

function clearCache() {
    console.log('after request')
    const clearCacheProcess = spawn('python', ['./clear_cache.py'])

    clearCacheProcess.stdout.on('data', data => console.log(data.toString()))
}

app.listen(port)
console.log(`listening on port: ${port}`)