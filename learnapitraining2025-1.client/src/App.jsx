import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import MealsPage from "./pages/MealsPage";

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <div>
        <MealsPage />
      </div>
    </>
  )
}

export default App
