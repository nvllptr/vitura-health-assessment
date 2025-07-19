import { useEffect } from "react"
import type { CreatePrescriptionFormValues } from "../types/Prescription"
import { useNavigate, useParams } from "react-router-dom"
import { useCreatePrescriptionMutation } from "../services/prescriptionsApi"
import { Button, Container, FormLabel } from "react-bootstrap"
import { Field, Form, Formik } from "formik"
import { PrescriptionSchema } from "../validation/prescriptionSchema"
import { toast } from "react-toastify"

export const CreatePrescription = () => {
  const { id } = useParams()
  const navigate = useNavigate()
  const [dispatchCreatePrescription, createPrescriptionResponse] = useCreatePrescriptionMutation()

  const initialValues = {
    drugName: "",
    dosage: "",
    datePrescribed: ""
  }

  const handleCloseModal = () => {
    navigate(-1)
  }

  const handleOnSubmit = (values: CreatePrescriptionFormValues) => {

    const prescription = {
      patientId: id,
      drugName: values.drugName,
      dosage: values.dosage,
      datePrescribed: values.datePrescribed
    }
    dispatchCreatePrescription(prescription)
  }

  useEffect(() => {
    if (createPrescriptionResponse.isSuccess) {
      toast.success("Successfully created prescription.")
      navigate(-1)

    } else if (createPrescriptionResponse.isError) {
      toast.error("Failed to create prescription.")
    }

  }, [createPrescriptionResponse.isSuccess, createPrescriptionResponse.isError, navigate])

  return (<>

    <Container>
      <div className="d-flex flex-row">
        <h4 className="flex-grow-1">Create Prescription</h4>
        <Button variant="outline-primary" onClick={handleCloseModal}>
          <i className="bi bi-x-lg"></i>
        </Button>
      </div>

      <Formik
        initialValues={initialValues}
        validationSchema={PrescriptionSchema}
        onSubmit={handleOnSubmit}
      >
        {({ errors, touched }) => (
          <Form>
            <div className="d-flex flex-column ">
              <FormLabel>Drug Name</FormLabel>
              <Field name="drugName" className="mb-2 mt-2"></Field>
              {
                errors.drugName && touched.drugName ?
                  (<p className="text-danger">{errors.drugName}</p>) :
                  null
              }

              <FormLabel className="mt-2">Drug Dosage</FormLabel>
              <Field name="dosage" className="mb-2"></Field>
              {
                errors.dosage && touched.dosage ?
                  (<p className="text-danger">{errors.dosage}</p>) :
                  null
              }

              <FormLabel className="mt-2">Date Prescribed</FormLabel>
              <Field type="date" name="datePrescribed" className="mb-2 form-control" />
              {
                errors.datePrescribed && touched.datePrescribed ?
                  (<p className="text-danger">{errors.datePrescribed}</p>) :
                  null
              }
              <Button type="submit">Create</Button>
            </div>
          </Form>
        )}
      </Formik>
    </Container>
  </>)
}