import { api } from "./api";
import { endpoints } from "./constants/endpoints";
import { PRESCRIPTIONS_TAG } from "./constants/tags";

export const prescriptionApi = api.injectEndpoints({
  endpoints: (builder) => ({
    getPrescriptions: builder.query({
      query: () => ({
        url: endpoints.PRESCRIPTIONS
      }),
      providesTags: [PRESCRIPTIONS_TAG]
    }),

    getPrescriptionById: builder.query({
      query: (id) => ({
        url: endpoints.PRESCRIPTIONS + "/" + id
      }),
      providesTags: [PRESCRIPTIONS_TAG]

    }),

    createPrescription: builder.mutation({
      query: (data) => ({
        url: endpoints.PRESCRIPTIONS,
        method: "POST",
        body: data
      }),
      invalidatesTags: [PRESCRIPTIONS_TAG]
    })
  })
})

export const {
  useCreatePrescriptionMutation,
  useGetPrescriptionsQuery,
  useGetPrescriptionByIdQuery,
} = prescriptionApi