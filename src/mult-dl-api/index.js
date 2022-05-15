const app = require('express')()
const port = 8080

app.get('/api/get-video', (req, res) => {
    const { spawn } = require('child_process')

    const target = req.query.target
    const format = req.query.format

    const pythonProcess = spawn('python', ['./download.py', target, format])

    pythonProcess.stdout.on('data', (data) => {
        const fileName = data.toString().trim()
        console.log(`sending file: ${fileName}`)
        res.download(`./${fileName}`)
        pythonProcess.stdout.removeAllListeners('data')
    })
})

app.listen(port)
console.log(`listening on port: ${port}`)