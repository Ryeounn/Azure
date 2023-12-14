const ctx3 = document.getElementById('total');
const colorctx3 = ["#F3AA60", "#EF6262", "#468B97", "#1D5B79"]
new Chart(ctx3, {
    type: 'bar',
    data: {
        labels: ['First Quarter', 'Second Quarter', 'Third Quarter', 'Fourth Quarter'],
        datasets: [{
            label: 'Revenue',
            data: [5129, 5358, 2769, 7894],
            borderWidth: 1,
            backgroundColor: colorctx3
        }]
    },
    options: {
        scales: {
            y: {
                beginAtZero: true
            }
        }
    }
});


const ctx2 = document.getElementById('order');
const colortx2 = ["#FFC93C", "#86E5FF", "#5BC0F8","#0081C9"]
new Chart(ctx2, {
    type: 'bar',
    data: {
        labels: ['First Quarter', 'Second Quarter', 'Third Quarter', 'Fourth Quarter'],
        datasets: [{
            label: 'Order',
            data: [103, 259, 89, 448],
            borderWidth: 1,
            backgroundColor: colortx2
        }]
    },
    options: {
        scales: {
            y: {
                beginAtZero: true
            }
        }
    }
});







