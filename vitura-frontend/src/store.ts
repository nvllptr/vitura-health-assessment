import { api } from "./services/api";
import { configureStore } from '@reduxjs/toolkit'

const store = configureStore({
  reducer: {
    [api.reducerPath]: api.reducer,
  },

  middleware: (getDefaultMiddleware) => getDefaultMiddleware().concat(api.middleware).concat(),

})

export type RootState = ReturnType<typeof store.getState>;
export default store;