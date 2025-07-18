import { Button, Card, Container, Table } from "react-bootstrap";
import { useGetPatientsQuery } from "../services/patientsApi";
import type { GetPatientDtoShort } from "../types/Patient";
import { routes } from "../routes";

export const Patients = () => {

  const patients = useGetPatientsQuery();

  return (<>
    <Container className="justify-content-center">
      <Card>
        <Card.Header>
          Patients
        </Card.Header>
        <Card.Body>
          <Table>
            <thead>
              <tr>
                <th>ID</th>
                <th>Full Name</th>
                <th>Date of Birth</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              {
                patients.data?.map((patient: GetPatientDtoShort) => {
                  return (
                    <tr key={patient.id}>

                      <td>{patient.id}</td>
                      <td>{patient.fullName}</td>
                      <td>{patient.dateOfBirth}</td>
                      <td>
                        <Button href={routes.PATIENTS + "/" + patient.id} variant="outline-primary">
                          <i className="bi bi-pencil-fill"></i>
                        </Button>
                      </td>
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
