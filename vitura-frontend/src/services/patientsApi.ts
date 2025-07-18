import type { GetPatientDtoLong, GetPatientDtoShort } from "../types/Patient";
import { api } from "./api";
import { endpoints } from "./constants/endpoints";
import { PRESCRIPTIONS_TAG } from "./constants/tags";

export const patientApi = api.injectEndpoints({
  endpoints: (builder) => ({
    getPatients: builder.query<GetPatientDtoShort[], void>({
      query: () => ({
        url: endpoints.PATIENTS
      }),
      providesTags: [PRESCRIPTIONS_TAG]

    }),

    getPatientById: builder.query<GetPatientDtoLong, number>({
      query: (id) => ({
        url: endpoints.PATIENTS + id
      }),
      providesTags: [PRESCRIPTIONS_TAG]

    }),


  })
})

export const {
  useGetPatientByIdQuery,
  useGetPatientsQuery
} = patientApi