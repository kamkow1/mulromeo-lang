import { AppShell } from '@mantine/core'
import { BrowserRouter, Routes, Route  } from 'react-router-dom'
import './App.css'
import Home from './Home'
import Navbar from './Navbar'
import Header from './Header'

function App() {
  return (
    <BrowserRouter>
      <AppShell 
        padding='xs' 
        fixed
        navbar={<Navbar />}
        header={<Header />}
      >
          <Routes>
            <Route path='/' element={<Home />} />
          </Routes>
      </AppShell>
    </BrowserRouter>
  )
}

export default App
