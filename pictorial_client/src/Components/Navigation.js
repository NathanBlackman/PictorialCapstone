import React from 'react';
import PropTypes from 'prop-types';
import {
  Nav,
  Navbar,
  NavbarBrand,
  // NavbarToggler,
  Collapse,
  NavItem,
  NavLink,
  UncontrolledDropdown,
  DropdownToggle,
  DropdownItem,
  DropdownMenu,
} from 'reactstrap';
import { signOutUser } from '../api/auth';

export default function Navigation({ user }) {
  return (
    <div>
      <Navbar
        color="light"
        expand="md"
        light
      >
        <NavbarBrand href="/pieces">
          <h1>Pictorial</h1>
        </NavbarBrand>
        <Collapse navbar>
          <Nav
            className="me-auto"
            navbar
          >
            <NavItem>
              <NavLink href="/pieces">
                Pieces
              </NavLink>
            </NavItem>
            <NavItem>
              <NavLink href="/giftform">
                New Gift
              </NavLink>
            </NavItem>
            <UncontrolledDropdown
              className="navbar-user"
              inNavbar
              nav
            >
              <DropdownToggle
                caret
                nav
              >
                <img
                  className="navbar-profile-pic"
                  alt={user.name}
                  src={user.image}
                />
                {user.user}
              </DropdownToggle>
              <DropdownMenu right>
                <DropdownItem>
                  {user.user}
                </DropdownItem>
                <DropdownItem divider />
                <DropdownItem>
                  <NavLink
                    className="sign-out-user"
                    onClick={signOutUser}
                  >
                    Sign Out
                  </NavLink>
                </DropdownItem>
              </DropdownMenu>
            </UncontrolledDropdown>
          </Nav>
        </Collapse>
      </Navbar>
    </div>
  );
}

Navigation.defaultProps = {
  user: null,
};

Navigation.propTypes = {
  user: PropTypes.oneOfType([
    PropTypes.bool,
    PropTypes.shape({
      name: PropTypes.string,
      image: PropTypes.string,
      uid: PropTypes.string,
      user: PropTypes.string,
    }),
  ]),
};