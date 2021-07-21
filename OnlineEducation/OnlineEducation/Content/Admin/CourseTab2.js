const steps2 = Array.from(document.querySelectorAll('form .step2'));
const nextBtn2 = document.querySelectorAll('form .next-btn2');
const prevBtn2 = document.querySelectorAll('form .previous-btn2');
// const submitBtn = document.querySelectorAll('form .submit-btn');
// const form2 = document.querySelector('form');


const accordionItemHeaders = document.querySelectorAll(".accordion-item-header");
// nextElementSibling trả về phần tử ngay sau phần tử được chỉ định, trong cùng một mức cây
// Thuộc tính scrollHeight trả về toàn bộ chiều cao của một phần tử tính bằng pixel, bao gồm cả 
// phần đệm, nhưng không trả về đường viền, thanh cuộn hoặc lề.
accordionItemHeaders.forEach(accordionItemHeader => {
    accordionItemHeader.addEventListener("click", event => {
        accordionItemHeader.classList.toggle("active");
        const accordionItemBody = accordionItemHeader.nextElementSibling;
        if (accordionItemHeader.classList.contains("active")) {
            accordionItemBody.style.maxHeight = accordionItemBody.scrollHeight + "px";
        } else {
            accordionItemBody.style.maxHeight = 0;
        }

    });
});


nextBtn2.forEach(button => {
    button.addEventListener('click', () => {
        changeStep2('next2');
    })
})

prevBtn2.forEach(button => {
    button.addEventListener('click', () => {
        changeStep2('prev2')
    })
})

function changeStep2(btn2) {
    let index2 = 0;
    const active2 = document.querySelector('form .step2.active');
    index2 = steps2.indexOf(active2);
    steps2[index2].classList.remove('active');
    if (btn2 === 'next2') {
        index2++;

    } else if (btn2 === 'prev2') {
        index2--;
    }
    steps2[index2].classList.add('active');
}

function createMenuItem(name) {
    var li = document.createElement("li");
    li.setAttribute("name", "Input2");
    li.textContent = name;
    return li;
}

function createMenuItem2(name) {
    var input = document.createElement("input");
    input.setAttribute("name", "input2");
    input.placeholder = name;
    input.style.width = '100%';
    input.style.b
    return input;
}

function creatMenu() {
    const menu = document.querySelector('#menu');
    var inputVal = document.getElementById("myInput").value;
    for (let index = 1; index <= inputVal; index++) {
        menu.appendChild(createMenuItem('Chương ' + index + ":"));
        menu.appendChild(createMenuItem2('Nhập Tiêu Đề Của Chương ' + index));
    }

    function addVideo() {
        const menu = document.querySelector('#menu');
        var inputVal = document.getElementById("myInput").value;
        for (let index = 1; index <= inputVal; index++) {

            menu.document.getElementById("#menu");
            menu.appendChild(createMenuItem2('Nhập Tiêu Đề Của Chương ' + index + "\n"));
        }
    }
}