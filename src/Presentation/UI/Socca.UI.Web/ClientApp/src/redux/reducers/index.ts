import { combineReducers } from 'redux';
import { PlayersReducer } from './playersReducer';

const rootReducer = combineReducers({
    playersReducer: PlayersReducer
  //some more reducers will come
});

export type ApplicationState = ReturnType<typeof rootReducer>;

export { rootReducer };