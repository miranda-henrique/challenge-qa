import http from 'k6/http';
import { check } from 'k6';
import { htmlReport } from 'https://raw.githubusercontent.com/benc-uk/k6-reporter/main/dist/bundle.js';

export const options = {
    scenarios: {
        spike_test: {
            executor: 'constant-vus',
            vus: 100,
            duration: '1m',
        },
    },
};

const headers = {
    Accept: 'text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7',
    'Accept-Language': 'pt-BR,pt;q=0.9',
    'Cache-Control': 'max-age=0',
    Connection: 'keep-alive',
    Referer: 'https://test.k6.io/my_messages.php',
    'Sec-Fetch-Dest': 'document',
    'Sec-Fetch-Mode': 'navigate',
    'Sec-Fetch-Site': 'same-origin',
    'Sec-Fetch-User': '?1',
    'Upgrade-Insecure-Requests': '1',
    'User-Agent':
        'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/135.0.0.0 Safari/537.36',
    'sec-ch-ua':
        '"Google Chrome";v="135", "Not-A.Brand";v="8", "Chromium";v="135"',
    'sec-ch-ua-mobile': '?0',
    'sec-ch-ua-platform': '"Windows"',
    Cookie: '_mkto_trk=id:356-YFG-389&token:_mch-k6.io-5e621be1d40a41314c0c3a65b47368c6; _lfa=LF1.1.ba6fa9958562a467.1744695846984; _hjSessionUser_1699068=eyJpZCI6IjEyMDYwMTJiLWIwMDctNTYxMi05MjhhLWRmYjg2MTA4NGY1MSIsImNyZWF0ZWQiOjE3NDQ2OTU4NDcwOTgsImV4aXN0aW5nIjpmYWxzZX0=; _hjSession_1699068=eyJpZCI6IjBlNzNlNDE1LTBjYjYtNDA3NC04NjFhLTFhOTQ0YWY3ZWE1MyIsImMiOjE3NDQ2OTU4NDcwOTksInMiOjAsInIiOjAsInNiIjowLCJzciI6MCwic2UiOjAsImZzIjoxLCJzcCI6MH0=; _ga=GA1.1.353587953.1744695848; _ga_H2LHZ4M8SN=GS1.1.1744695847.1.1.1744695849.58.0.0; csrf=MzQxODQ1NDEy; uid=3221; sid=39b77ac6-39c4-4c43-98b3-6b2816682036; csrf=ODgzNzg0Njgx',
};

export default function () {
    const res = http.get(
        'https://test.k6.io/my_messages.php',
        {
            headers: headers,
        }
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
        [`1000VU_report_${timestamp}.html`]:
            htmlReport(data),
    };
}
