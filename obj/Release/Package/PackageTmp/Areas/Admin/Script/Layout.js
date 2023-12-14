const body = document.querySelector("body"),
    sidebar = body.querySelector(".sidebar"),
    toggle = body.querySelector(".toggle"),
    searchBtn = body.querySelector(".search-box"),
    modeSwitch = body.querySelector(".toggle-switch"),
    modeText = body.querySelector(".mode-text");

toggle.addEventListener("click", () => {
    sidebar.classList.toggle("close");
});

searchBtn.addEventListener("click", () => {
    sidebar.classList.remove("close");
});

//      modeSwitch.addEventListener("click", ()=>{
//         body.classList.toggle("dark"); 
//         
//         if(body.classList.contains("dark")){
//             modeText.innerText = "Light Mode"
//         }else{
//             modeText.innerText = "Dark Mode"
//         }
//      });

let mode = localStorage.getItem('darkmode');
if (mode == 'true') {
    body.classList.add("dark");
    modeText.innerText = "Light Mode";
} else { }
modeSwitch.addEventListener('click', () => {
    if (body.classList.contains("dark")) {
        modeText.innerText = "Dark Mode"
    } else {
        modeText.innerText = "Light Mode"
    }
    let mode = body.classList.toggle('dark');
    // save mode
    localStorage.setItem('darkmode', mode);
});

