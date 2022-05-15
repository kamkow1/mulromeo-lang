const app = require('express')()
const port = 8080

app.get('/api/get-video', (req, res) => {
    const { spawn } = require('child_process')
    const pythonProcess = spawn('python', ['./download.py'])

    pythonProcess.stdout.on('data', (data) => {
        res.send(data)
    })
})

app.listen(port)
console.log(`listening on port: ${port}`)