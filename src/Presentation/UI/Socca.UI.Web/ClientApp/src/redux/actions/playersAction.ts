import * as PlayerService from '../../services/player.http.service'

import { Dispatch } from 'react';

import { Player } from '../../interfaces/Player';

export interface PlayerAction {
    readonly type: 'ON_PAGE_LOAD_GET_PLAYERS';
    payload: Player[];
}

export interface PlayerErrorAction {
  readonly type: 'ON_ERROR';
  payload: any;
}

export type PlayersAction = PlayerAction | PlayerErrorAction;

// we need to dispatch action
export const onPageLoadGetPlayers = () => {
    return async (dispatch: Dispatch<PlayersAction>) => {
      try {
        var players = await PlayerService.Get()  
        if (!players) {
          dispatch({
            type: 'ON_ERROR',
            payload: 'Could not get players',
          });
        } else {
          dispatch({
            type: 'ON_PAGE_LOAD_GET_PLAYERS',
            payload: players,
          });
        }
      } catch (error) {
        dispatch({
          type: 'ON_ERROR',
          payload: error,
        });
      }
    };
  };
