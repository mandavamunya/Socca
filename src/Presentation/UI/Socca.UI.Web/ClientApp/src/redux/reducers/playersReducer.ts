import { Player } from '../../interfaces/Player';
import { PlayersAction } from '../actions/playersAction';

type PlayerState = {
    players: Player[];
    playersError: string | undefined;
};

const initialState = {
  players: [] as Player [],
  playersError: undefined,
};

const PlayersReducer = (state: PlayerState = initialState, action: PlayersAction) => {
  switch (action.type) {
    case 'ON_PAGE_LOAD_GET_PLAYERS':
      return {
        ...state,
        players: action.payload,
      };
    case 'ON_ERROR':
      return {
        ...state,
        playersError: action.payload,
      };
    default:
      return state;
  }
};

export { PlayersReducer };