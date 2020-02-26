// upload photo
var uppy = Uppy.Core()
    .use(Uppy.Dashboard, {
        inline: true,
        height: 500,
        target: '#drag-drop-area',
        //local: Russian
    })
    .use(Uppy.Tus, { endpoint: 'https://master.tus.io/files/' })

uppy.on('complete', (result) => {
    console.log('Upload complete! We’ve uploaded these files:', result.successful)
})
