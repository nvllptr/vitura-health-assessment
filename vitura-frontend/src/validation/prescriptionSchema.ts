import * as Yup from 'yup';

const REQUIRED_MESSAGE = "Required Field"

export const PrescriptionSchema = Yup.object().shape({
  drugName: Yup.string().required(REQUIRED_MESSAGE),
  dosage: Yup.string().required(REQUIRED_MESSAGE),
  datePrescribed: Yup.string().required(REQUIRED_MESSAGE),
})