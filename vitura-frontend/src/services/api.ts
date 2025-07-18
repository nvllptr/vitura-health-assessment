import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { PRESCRIPTIONS_TAG } from "./constants/tags.ts";


const baseQuery = fetchBaseQuery({
  baseUrl: import.meta.env.VITE_BASE_URL,
});

export const api = createApi({
  reducerPath: "api",
  baseQuery: baseQuery,
  tagTypes: [PRESCRIPTIONS_TAG],
  endpoints: () => ({

  }),
});