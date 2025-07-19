import { ToastContainer } from "react-toastify"
import { Provider } from "react-redux"
import { Route, Routes, useLocation } from "react-router-dom"
import store from "./store"
import { Patients } from "./pages/Patients"
import { PatientDetails } from "./pages/PatientDetails"
import { routes } from "./routes"
import { CreatePrescription } from "./pages/CreatePrescription"
import { NavbarLayout } from "./layouts/NavbarLayout"
import { ModalLayout } from "./layouts/ModalLayout"

function App() {
  const location = useLocation()
  const backgroundLocation = location.state && location.state.backgroundLocation

  return (
    <>
      <ToastContainer />
      <Provider store={store} >
        <Routes location={backgroundLocation || location}>
          <Route element={<NavbarLayout />}>
            <Route index element={<Patients />} />
            <Route path={routes.PATIENT_DETAILS} element={<PatientDetails />} />
          </Route>
        </Routes>
        {
          backgroundLocation &&
          <Routes>
            <Route element={<ModalLayout />}>
              <Route path={routes.CREATE_PRESCRIPTION} element={<CreatePrescription />} />
            </Route>
          </Routes>
        }
      </Provider>
    </>
  )
}

export default App
