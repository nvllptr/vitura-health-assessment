import type { GetPrescriptionDto } from "./Prescription";

export interface GetPatientDtoShort {
  id: number,
  fullName: string,
  dateOfBirth: string,
}

export interface GetPatientDtoLong extends GetPatientDtoShort {
  prescriptions: GetPrescriptionDto[]
}

