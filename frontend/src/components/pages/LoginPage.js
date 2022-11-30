import React from 'react'
import { Link } from 'react-router-dom'
import {useEffect, useState } from "react";



import '../../App.css'
import BackgroundImage from '../../assets/images/bg.png'


export default function SignInPage() {

    const getInitialUserRole = () => {
        const userRole = "Admin";
        return userRole;
      };
    
      const [userRole, setuserRole] = useState(getInitialUserRole);
    
      const handleChange = (e) => {
        setuserRole(e.target.value);
        console.log("userRole",{userRole})
      };

      const [MenuItems, setMenuItems] = useState([]);
	  
		 useEffect(() => {
		  getMenuItems();
		  }, []);
	  
		async function getMenuItems() {
		  const response = await fetch('http://localhost:8708/api/MenuItems/userRole='+userRole);
		  const MenuItems = await response.json();
		  setMenuItems(MenuItems);
      return(<Link to="/navbar"  params={{menuItems:MenuItems}}></Link>);

		}
  return (
    <header style={HeaderStyle}>
      <div class="center">

         <h2>Sign In</h2>
            <form>
                <p>
                    <label>User</label><br/>
                      <select value={userRole} onChange={handleChange} >
                               <option value="Admin">Admin</option>
                                <option value="DepartmentHead">Department Head</option>
                                <option value="ExecutiveDeveloper">Executive Developer</option>
                                <option value="JuniorDeveloper">Junior Developer</option>
                      </select>
                      
                </p>
                <p>
                <button id="sub_btn"  onClick="getMenuItems()">Login</button>
                </p>

        </form>
      </div>
     </header>
    )
}

const HeaderStyle = {
    width: "100%",
    height: "100vh",
    background: `url(${BackgroundImage})`,
    backgroundPosition: "center",
    backgroundRepeat: "no-repeat",
    backgroundSize: "cover"
}
