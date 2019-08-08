declare global {
    interface RouterMeta {
        title: string;
    }
    interface Router {
        path: string;
        name: string;
        icon?: string;
        permission?: string;
        meta?: RouterMeta;
        component: any;
        children?: Array<Router>;
    }
    interface System {
        import(request: string): Promise<any>
    }
    var System: System
}

import main from '../views/main.vue';

export const locking = {
    path: '/locking',
    name: 'locking',
    meta: { title: 'Locking' },
    component: () => import('../components/lockscreen/components/locking-page.vue')
};
export const loginRouter: Router = {
    path: '/',
    name: 'login',
    meta: {
        title: 'LogIn'
    },
    component: () => import('../views/login.vue')
};
export const otherRouters: Router = {
    path: '/main',
    name: 'main',
    permission: '',
    meta: { title: 'SystemManage' },
    component: main,
    children: [
        { path: 'home', meta: { title: 'HomePage' }, name: 'home', component: () => import('../views/home/home.vue') }
    ]
}
export const appRouters: Array<Router> = [{
    path: '/setting',
    name: 'setting',
    permission: '',
    meta: { title: 'SystemManage' },
    icon: '&#xe68a;',
    component: main,
    children: [
        { path: 'user', permission: 'Admin.Users', meta: { title: 'Users' }, name: 'user', component: () => import('../views/setting/user/user.vue') },
        { path: 'role', permission: 'Admin.Roles', meta: { title: 'Roles' }, name: 'role', component: () => import('../views/setting/role/role.vue') },
        { path: 'tenant', permission: 'Admin.Tenants', meta: { title: 'Tenants' }, name: 'tenant', component: () => import('../views/setting/tenant/tenant.vue') }
    ]
}]
export const routers = [
    loginRouter,
    locking,
    ...appRouters,
    otherRouters
];
