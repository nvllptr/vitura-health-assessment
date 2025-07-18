
export interface GetPrescriptionDto {
  id: number,
  patientId: number,
  drugName: string,
  dosage: string,
  datePrescribed: string
}

export interface CreatePrescriptionFormValues {
  drugName: string,
  dosage: string,
  datePrescribed: string,
}

export interface CreatePrescriptionDto extends CreatePrescriptionFormValues {
  patientId: number,
}

