const app               = require('express')()
const ytdl              = require('ytdl-core')
const morgan            = require('morgan')
const http              = require('http')
const https             = require('https')

const port = process.env.PORT || 3000

app.use(morgan('dev'))

app.get('/api/media', (req, res) => {
    
    const target = req.query.target
    const format = req.query.format
    
    ytdl(target, { format: format }).pipe(res)
})

app.get('/api/image', (req, res) => {
    const target = new URL(req.query.target)

    if (target.protocol.includes('http')) http.get(target, resp => resp.pipe(res))

    if (target.protocol.includes('https')) https.get(target, resp => resp.pipe(res))
})


app.listen(port)
console.log(`listening on port: ${port}`)