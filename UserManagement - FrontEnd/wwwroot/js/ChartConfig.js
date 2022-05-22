export function BarChartConfiguration(config)
{
    var config = JSON.parse(config)

    var chartContent = document.getElementById(config.ChartId).getContext('2d');

    const configChart = new Chart(chartContent,
        {
            type: 'bar',
            data: {
                labels: config.Label,
                datasets: [{
                   label: config.Name,
                    data: config.Data,
                    backgroundColor: [
                        'rgba(255, 99, 132, 0.2)'
                    ],
                    borderColor: [
                        'rgba(255, 99, 132, 1)'
                    ],
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
};

export function PieChartConfiguration(config, chartId)
{
    var config = JSON.parse(config)

    var chartContent = document.getElementById(chartId).getContext('2d');

    const configChart = new Chart(chartContent, config);
}