let amountElement = document.getElementById('amount');
let amount = amountElement.value;

let render = (amount) => {
    amountElement.value = amount
}
//Handle Plus
let handlePlus = () => {
    amount++
    render(amount);
}

//Handle Minus
let handleMinus = () => {
    if (amount > 1)
        amount--;
    render(amount);
}

amountElement.addEventListener('input', () => {
    amount = amountElement.value;
    amount = parseInt(amount);
    amount = (isNaN(amount) ||amount == 0) ? 1 : amount;
    render(amount);
});
