import { useLocation, useNavigate, useParams } from "react-router-dom"
import { useGetPatientByIdQuery } from "../services/patientsApi"
import { Button, Card, Container, Table } from "react-bootstrap"
import type { GetPrescriptionDto } from "../types/Prescription"
import { routes } from "../routes"

export const PatientDetails = () => {
  const { id } = useParams()
  const navigate = useNavigate()
  const location = useLocation()
  const patient = useGetPatientByIdQuery(Number(id))

  const handleClickCreate = () => {
    const route = routes.CREATE_PRESCRIPTION.replace(":id", id as string)
    navigate(route, { state: { backgroundLocation: location } })
  }

  return (<>
    <Container>
      <h1>{patient.data?.fullName}</h1>
      <p>Date of Birth: {patient.data?.dateOfBirth}</p>

      <Card>
        <Card.Header className="d-flex">
          <div className="flex-grow-1">
            Prescriptions
          </div>
          <div>
            <Button onClick={handleClickCreate} className="btn-sm">
              <i className="bi bi-plus-lg"></i>
            </Button>
          </div>
        </Card.Header>
        <Card.Body>
          <Table>
            <thead>
              <tr>
                <th>ID</th>
                <th>Name</th>
                <th>Dosage</th>
                <th>Date Prescribed</th>
              </tr>
            </thead>
            <tbody>
              {
                patient.data?.prescriptions.map((prescription: GetPrescriptionDto) => {
                  return (
                    <tr key={prescription.id}>
                      <td>{prescription.id}</td>
                      <td>{prescription.drugName}</td>
                      <td>{prescription.dosage}</td>
                      <td>{prescription.datePrescribed}</td>
                    </tr>
                  )
                })
              }
            </tbody>
          </Table>
        </Card.Body>
      </Card>
    </Container>
  </>)

}