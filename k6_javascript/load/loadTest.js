import http from 'k6/http';
import { check } from 'k6';

export const options = {
    scenarios: {
        ramping_load_test: {
            executor: 'ramping-vus',
            startVUs: 0,
            stages: [
                { duration: '1m', target: 100 },
                { duration: '2m', target: 100 },
                { duration: '1m', target: 500 },
                { duration: '2m', target: 500 },
                { duration: '1m', target: 1000 },
                { duration: '2m', target: 1000 },
                { duration: '1m', target: 0 },
            ],
            gracefulRampDown: '30s',
        },
    },
    thresholds: {
        http_req_duration: ['p(95)<2000'],
        http_req_failed: ['rate<0.1'],
    },
};

export default function () {
    const res = http.get(
        'https://test.k6.io/flip_coin.php?bet=heads'
    );

    check(res, {
        'status is 200': (res) =>
            res.status === 200,
        'contains result text': (res) =>
            res.body.includes('Toss result:'),
    });
}
