import http from 'k6/http';
import { check } from 'k6';
import { htmlReport } from 'https://raw.githubusercontent.com/benc-uk/k6-reporter/main/dist/bundle.js';

export const options = {
    scenarios: {
        spike_test: {
            executor: 'constant-vus',
            vus: 500,
            duration: '1m',
        },
    },
};

export default function () {
    const res = http.get(
        'https://test.k6.io/flip_coin.php?bet=heads'
    );
    check(res, {
        'status is 200': (res) =>
            res.status === 200,
    });
}

export function handleSummary(data) {
    const now = new Date();
    const preencherZero = (num) =>
        num.toString().padStart(2, '0');
    const timestamp = `${now.getFullYear()}${preencherZero(now.getMonth() + 1)}${preencherZero(now.getDate())}_${preencherZero(now.getHours())}${preencherZero(now.getMinutes())}${preencherZero(now.getSeconds())}`;

    return {
        [`500VU_report_${timestamp}.html`]:
            htmlReport(data),
    };
}
