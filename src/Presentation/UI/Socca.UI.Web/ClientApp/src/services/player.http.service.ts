import { Player } from "../interfaces/Player";
import * as Utils from "../utils/index";

let baseURL = Utils.BASE_URL + "api/player";

export async function Get() : Promise<Player[]>
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
