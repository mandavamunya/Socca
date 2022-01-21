import { Stadium } from "../interfaces/Stadium";
import * as Utils from "../utils/index";

let baseURL = Utils.BASE_URL + "api/player";

export async function Get() : Promise<Stadium[]>
{
    var promise = await fetch(baseURL, {
        method: 'GET',
        headers: {
          'Accept': 'application/json',
          "Content-type": "application/json; charset=UTF-8"
        }
    });
    if (promise.status == 200)
    {
        var response = await promise.json()
        return response;
    } 
    else 
    {
        return []
    }
}
