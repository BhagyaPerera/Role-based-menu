import React from 'react';

export default function Navigationbar({MenuItems}){

	  return(

	   <nav>
		<label>User</label><br/>
		<ul>
        {{MenuItems}.map((menu, index) => {
          return (
            <li  key={index}>
              <a href="">{menu.title}</a>
            </li>
          );
        })}
        </ul>
	  </nav>)
};




