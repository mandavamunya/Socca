import { createContext, ReactNode, useContext, useState } from 'react';

type DrawerContextType = {
    drawerOpen: boolean;
    handleDrawerOpen: () => void;
    handleDrawerClose: () => void;    
};

type Props = {
  children: ReactNode;
};

let drawerContextDefaultValues: DrawerContextType = {
  drawerOpen: false,
  handleDrawerOpen: () => {},
  handleDrawerClose: () => {},
};

let DrawerContext = createContext<DrawerContextType>(drawerContextDefaultValues);

export function useDrawerContext() {
  return useContext(DrawerContext);
}


export function DrawerContextProvider({ children }: Props) {
  const [drawerOpen, setDrawerOpen] = useState(false);

  let values: DrawerContextType = {
    drawerOpen: drawerOpen,
    handleDrawerOpen: () => {setDrawerOpen(true)},
    handleDrawerClose: () => {setDrawerOpen(false)},
  };
  
  return (
    <>
        <DrawerContext.Provider value={values}>
            {children}
        </DrawerContext.Provider>
    </>
  );
}
