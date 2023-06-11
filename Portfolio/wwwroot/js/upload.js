
function formatBytes(bytes, decimals = 2) {
    if (!bytes) return '0 Bytes'

    const k = 1024
    const dm = decimals < 0 ? 0 : decimals
    const sizes = ['Bytes', 'KB', 'MB', 'GB', 'TB', 'PB', 'EB', 'ZB', 'YB']

    const i = Math.floor(Math.log(bytes) / Math.log(k))

    return `${parseFloat((bytes / Math.pow(k, i)).toFixed(dm))} ${sizes[i]}`
}

export function upload(selector, options = {}) {
    let files = []
    //Настройка инпута
    const input = document.querySelector(selector)
    input.setAttribute('multiple', options.multi)
    // Галерея
    const preview = document.createElement('div')
    preview.classList.add('project-images__gallery')
    // Кнопка "открыть"
    const open = document.createElement('button')
    open.classList.add('btn')
    open.textContent = 'Открыть'
    
    if (options.accept && Array.isArray(options.accept)) {
        input.setAttribute('accept', options.accept.join(','))
    }

    input.insertAdjacentElement('afterend', open)
    const tools = document.querySelector('.project-images__tools')
    tools.insertAdjacentElement('afterend', preview)
    // end
    const triggerInput = () => {
        console.log("create")
        input.click()
    }
    const changeHandler = event => {
        console.log("create")
        if (event.target.files.length == 0) {
            return
        }

        files = Array.from(event.target.files)
        files.forEach(file => {
            if (!file.type.match('image')) {
                return
            }

            const reader = new FileReader()
            reader.onload = ev => {
                const src = ev.target.result
                console.log("create")
                preview.insertAdjacentHTML('afterbegin', `
                <div class="gallery-image">
                    <div class="image-remove" data-name="${file.name}">&times;</div>
                    <img src="${src}" alt="${file.name}"/>
                    <div class="image-info">
                        <span>${file.name}</span>
                        ${formatBytes(file.size)}
                    </div>
                </div>
                `)
            }
            reader.readAsDataURL(file)
        })

    }

    const removeHandler = event => {
        if (!event.target.dataset.name) {
            return
        }

        const { name } = event.target.dataset
        files = files.filter(file => file.name !== name)

        const block = preview.querySelector(`[data-name="${name}"]`).parentElement

        block.classList.add('removing')
        setTimeout(() => block.remove(), 150)
    }

    open.addEventListener('click', triggerInput)
    preview.addEventListener('click', removeHandler)
    input.addEventListener('change', changeHandler)
}