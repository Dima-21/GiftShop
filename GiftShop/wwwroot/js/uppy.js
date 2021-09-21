
//// upload photo
//const uppy = Uppy.Core()
//    .use(Uppy.Dashboard, {
//        inline: true,
//        height: 500,
//        target: '#drag-drop-area',
//        //local: Russian
//    })
//    .use(Uppy.Tus, { endpoint: 'https://master.tus.io/files/' })

//uppy.on('complete', (result) => {
//    console.log('Upload complete! We’ve uploaded these files:', result.successful);
//})

//uppy.on('file-added', (files) => {
//    const defaultStore = require('@uppy/store-default');
//    const prettyBytes = require('pretty-bytes');
//    const items = uppy.getFiles();
//    const listfiles = items.map((file) =>
//        `<li>${file.name}</li>`).join('');

//    document.querySelector('.file-list').innerHTML = `<ul>${listfiles}</ul>`;

//})


const Uppy = require('@uppy/core')
const Dashboard = require('@uppy/dashboard')
const GoogleDrive = require('@uppy/google-drive')
const Dropbox = require('@uppy/dropbox')
const Instagram = require('@uppy/instagram')
const Facebook = require('@uppy/facebook')
const OneDrive = require('@uppy/onedrive')
const Webcam = require('@uppy/webcam')
const Tus = require('@uppy/tus')

const uppy = Uppy({
    debug: true,
    autoProceed: false,
    restrictions: {
        maxFileSize: 1000000,
        maxNumberOfFiles: 3,
        minNumberOfFiles: 2,
        allowedFileTypes: ['image/*', 'video/*']
    }
})
    .use(Dashboard, {
        trigger: '.UppyModalOpenerBtn',
        inline: true,
        target: '.DashboardContainer',
        replaceTargetContent: true,
        showProgressDetails: true,
        note: 'Images and video only, 2–3 files, up to 1 MB',
        height: 470,
        metaFields: [
            { id: 'name', name: 'Name', placeholder: 'file name' },
            { id: 'caption', name: 'Caption', placeholder: 'describe what the image is about' }
        ],
        browserBackButtonClose: true
    })
    .use(GoogleDrive, { target: Dashboard, companionUrl: 'https://companion.uppy.io' })
    .use(Dropbox, { target: Dashboard, companionUrl: 'https://companion.uppy.io' })
    .use(Instagram, { target: Dashboard, companionUrl: 'https://companion.uppy.io' })
    .use(Facebook, { target: Dashboard, companionUrl: 'https://companion.uppy.io' })
    .use(OneDrive, { target: Dashboard, companionUrl: 'https://companion.uppy.io' })
    .use(Webcam, { target: Dashboard })
    .use(Tus, { endpoint: 'https://master.tus.io/files/' })

uppy.on('complete', result => {
    console.log('successful files:', result.successful)
    console.log('failed files:', result.failed)
})