const ctx1 = document.getElementById('revenue');

new Chart(ctx1, {
    type: 'pie',
    data: {
        labels: ['Nike', 'Adidas', 'Puma', 'Converse'],
        datasets: [{
            label: 'Revenue',
            data: [15, 39, 32, 14],
            borderWidth: 1
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
const barColors = ["red", "green", "blue", "orange", "brown"];
new Chart(ctx2, {
    type: 'bar',
    data: {
        labels: ['Nike', 'Adidas', 'Puma', 'Converse'],
        datasets: [{
            label: 'Order',
            data: [55, 49, 44, 24, 15],
            borderWidth: 1,
            backgroundColor: barColors,
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

const ctx3 = document.getElementById('product');
const barColorss = [
    "#b91d47",
    "#00aba9",
    "#2b5797",
    "#e8c3b9",
    "#1e7145"
];
new Chart(ctx3, {
    type: 'doughnut',
    data: {
        labels: ['Nike', 'Adidas', 'Puma', 'Converse'],
        datasets: [{
            label: 'Product',
            data: [35, 39, 14, 12],
            borderWidth: 1,
            backgroundColor: barColorss,
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

const ctx4 = document.getElementById('inventory');

new Chart(ctx4, {
    type: 'polarArea',
    data: {
        labels: ['Nike', 'Adidas', 'Puma', 'Converse'],
        datasets: [{
            label: 'inventory',
            data: [25, 39, 14, 22],
            borderWidth: 1,
            backgroundColor: [
                'rgb(255, 99, 132)',
                'rgb(75, 192, 192)',
                'rgb(255, 205, 86)',
                'rgb(201, 203, 207)',

            ]
        }],
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    }
});


