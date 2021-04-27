const _baseUrl = 'https://localhost:5003/';
const _headers = {
    'Accept': 'application/json',
    "Content-type": "application/json; charset=UTF-8"
};

export async function Get(path: string)
{
    var promise = await fetch(_baseUrl + path, {
        method: 'GET',
        headers: _headers
    });
    return promise;
};

export async function Post(path: string, json: string)
{
    var promise = await fetch(_baseUrl + path, {
        method: 'POST',
        headers: _headers,
        body: json
    });
    return promise;
}