import http from 'k6/http';
import { check } from 'k6';

export default function () {
    const res = http.get('https://azureload-bsh9exf8bkd9bafq.canadacentral-01.azurewebsites.net/api/Categories');
    check(res, {
        'status is 200': (r) => r.status === 200,
        'response time is less than 2 seconds': (r) => r.timings.duration < 2000,
    });
}
