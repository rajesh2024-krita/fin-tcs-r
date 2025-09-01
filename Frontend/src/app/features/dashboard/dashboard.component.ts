
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AuthService, UserInfo } from '../../core/services/auth.service';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, RouterModule],
  template: `
    <div class="min-h-screen bg-gray-50">
      <!-- Navigation -->
      <nav class="bg-white shadow">
        <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div class="flex justify-between h-16">
            <div class="flex items-center">
              <h1 class="text-xl font-semibold text-gray-900">Fintcs Dashboard</h1>
            </div>
            
            <div class="flex items-center space-x-4">
              <span class="text-sm text-gray-700">{{ currentUser?.name }}</span>
              <span class="inline-flex items-center px-2.5 py-0.5 rounded-full text-xs font-medium bg-blue-100 text-blue-800">
                {{ currentUser?.role }}
              </span>
              <button
                (click)="logout()"
                class="text-gray-500 hover:text-gray-700 px-3 py-2 rounded-md text-sm font-medium"
              >
                Logout
              </button>
            </div>
          </div>
        </div>
      </nav>

      <div class="max-w-7xl mx-auto py-6 sm:px-6 lg:px-8">
        <!-- Dashboard Content -->
        <div class="px-4 py-6 sm:px-0">
          <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
            
            <!-- Super Admin Dashboard -->
            <div *ngIf="currentUser?.role === 'SuperAdmin'" class="col-span-full">
              <h2 class="text-2xl font-bold text-gray-900 mb-4">Super Admin Dashboard</h2>
              <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-4">
                <div class="bg-white overflow-hidden shadow rounded-lg">
                  <div class="p-5">
                    <div class="flex items-center">
                      <div class="flex-shrink-0">
                        <div class="w-8 h-8 bg-blue-500 rounded-full flex items-center justify-center">
                          <span class="text-white text-sm font-bold">S</span>
                        </div>
                      </div>
                      <div class="ml-5 w-0 flex-1">
                        <dl>
                          <dt class="text-sm font-medium text-gray-500 truncate">Total Societies</dt>
                          <dd class="text-lg font-medium text-gray-900">{{ stats.totalSocieties }}</dd>
                        </dl>
                      </div>
                    </div>
                  </div>
                  <div class="bg-gray-50 px-5 py-3">
                    <div class="text-sm">
                      <a routerLink="/societies" class="font-medium text-blue-600 hover:text-blue-500">
                        Manage Societies
                      </a>
                    </div>
                  </div>
                </div>

                <div class="bg-white overflow-hidden shadow rounded-lg">
                  <div class="p-5">
                    <div class="flex items-center">
                      <div class="flex-shrink-0">
                        <div class="w-8 h-8 bg-green-500 rounded-full flex items-center justify-center">
                          <span class="text-white text-sm font-bold">U</span>
                        </div>
                      </div>
                      <div class="ml-5 w-0 flex-1">
                        <dl>
                          <dt class="text-sm font-medium text-gray-500 truncate">Total Users</dt>
                          <dd class="text-lg font-medium text-gray-900">{{ stats.totalUsers }}</dd>
                        </dl>
                      </div>
                    </div>
                  </div>
                  <div class="bg-gray-50 px-5 py-3">
                    <div class="text-sm">
                      <a routerLink="/users" class="font-medium text-green-600 hover:text-green-500">
                        Manage Users
                      </a>
                    </div>
                  </div>
                </div>

                <div class="bg-white overflow-hidden shadow rounded-lg">
                  <div class="p-5">
                    <div class="flex items-center">
                      <div class="flex-shrink-0">
                        <div class="w-8 h-8 bg-yellow-500 rounded-full flex items-center justify-center">
                          <span class="text-white text-sm font-bold">M</span>
                        </div>
                      </div>
                      <div class="ml-5 w-0 flex-1">
                        <dl>
                          <dt class="text-sm font-medium text-gray-500 truncate">Total Members</dt>
                          <dd class="text-lg font-medium text-gray-900">{{ stats.totalMembers }}</dd>
                        </dl>
                      </div>
                    </div>
                  </div>
                  <div class="bg-gray-50 px-5 py-3">
                    <div class="text-sm">
                      <a routerLink="/members" class="font-medium text-yellow-600 hover:text-yellow-500">
                        Manage Members
                      </a>
                    </div>
                  </div>
                </div>

                <div class="bg-white overflow-hidden shadow rounded-lg">
                  <div class="p-5">
                    <div class="flex items-center">
                      <div class="flex-shrink-0">
                        <div class="w-8 h-8 bg-red-500 rounded-full flex items-center justify-center">
                          <span class="text-white text-sm font-bold">L</span>
                        </div>
                      </div>
                      <div class="ml-5 w-0 flex-1">
                        <dl>
                          <dt class="text-sm font-medium text-gray-500 truncate">Active Loans</dt>
                          <dd class="text-lg font-medium text-gray-900">{{ stats.activeLoans }}</dd>
                        </dl>
                      </div>
                    </div>
                  </div>
                  <div class="bg-gray-50 px-5 py-3">
                    <div class="text-sm">
                      <a routerLink="/loans" class="font-medium text-red-600 hover:text-red-500">
                        Manage Loans
                      </a>
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <!-- Society Admin Dashboard -->
            <div *ngIf="currentUser?.role === 'SocietyAdmin'" class="col-span-full">
              <h2 class="text-2xl font-bold text-gray-900 mb-4">Society Admin Dashboard</h2>
              <p class="text-gray-600 mb-6">{{ currentUser?.societyName }}</p>
              
              <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
                <div class="bg-white overflow-hidden shadow rounded-lg">
                  <div class="p-5">
                    <div class="flex items-center">
                      <div class="flex-shrink-0">
                        <div class="w-8 h-8 bg-blue-500 rounded-full flex items-center justify-center">
                          <span class="text-white text-sm font-bold">M</span>
                        </div>
                      </div>
                      <div class="ml-5 w-0 flex-1">
                        <dl>
                          <dt class="text-sm font-medium text-gray-500 truncate">Society Members</dt>
                          <dd class="text-lg font-medium text-gray-900">{{ stats.societyMembers }}</dd>
                        </dl>
                      </div>
                    </div>
                  </div>
                  <div class="bg-gray-50 px-5 py-3">
                    <div class="text-sm">
                      <a routerLink="/members" class="font-medium text-blue-600 hover:text-blue-500">
                        Manage Members
                      </a>
                    </div>
                  </div>
                </div>

                <div class="bg-white overflow-hidden shadow rounded-lg">
                  <div class="p-5">
                    <div class="flex items-center">
                      <div class="flex-shrink-0">
                        <div class="w-8 h-8 bg-green-500 rounded-full flex items-center justify-center">
                          <span class="text-white text-sm font-bold">L</span>
                        </div>
                      </div>
                      <div class="ml-5 w-0 flex-1">
                        <dl>
                          <dt class="text-sm font-medium text-gray-500 truncate">Active Loans</dt>
                          <dd class="text-lg font-medium text-gray-900">{{ stats.societyLoans }}</dd>
                        </dl>
                      </div>
                    </div>
                  </div>
                  <div class="bg-gray-50 px-5 py-3">
                    <div class="text-sm">
                      <a routerLink="/loans" class="font-medium text-green-600 hover:text-green-500">
                        Manage Loans
                      </a>
                    </div>
                  </div>
                </div>

                <div class="bg-white overflow-hidden shadow rounded-lg">
                  <div class="p-5">
                    <div class="flex items-center">
                      <div class="flex-shrink-0">
                        <div class="w-8 h-8 bg-yellow-500 rounded-full flex items-center justify-center">
                          <span class="text-white text-sm font-bold">P</span>
                        </div>
                      </div>
                      <div class="ml-5 w-0 flex-1">
                        <dl>
                          <dt class="text-sm font-medium text-gray-500 truncate">Pending Approvals</dt>
                          <dd class="text-lg font-medium text-gray-900">{{ stats.pendingApprovals }}</dd>
                        </dl>
                      </div>
                    </div>
                  </div>
                  <div class="bg-gray-50 px-5 py-3">
                    <div class="text-sm">
                      <a href="#" class="font-medium text-yellow-600 hover:text-yellow-500">
                        View Pending
                      </a>
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <!-- User Dashboard -->
            <div *ngIf="currentUser?.role === 'User'" class="col-span-full">
              <h2 class="text-2xl font-bold text-gray-900 mb-4">User Dashboard</h2>
              <p class="text-gray-600 mb-6">{{ currentUser?.societyName }}</p>
              
              <div class="grid grid-cols-1 md:grid-cols-2 gap-4">
                <div class="bg-white overflow-hidden shadow rounded-lg">
                  <div class="p-5">
                    <h3 class="text-lg font-medium text-gray-900">Society Information</h3>
                    <p class="text-sm text-gray-500 mt-1">View society details and financial information</p>
                  </div>
                  <div class="bg-gray-50 px-5 py-3">
                    <div class="text-sm">
                      <a routerLink="/societies" class="font-medium text-blue-600 hover:text-blue-500">
                        View Society Details
                      </a>
                    </div>
                  </div>
                </div>

                <div class="bg-white overflow-hidden shadow rounded-lg">
                  <div class="p-5">
                    <h3 class="text-lg font-medium text-gray-900">Reports</h3>
                    <p class="text-sm text-gray-500 mt-1">Access financial reports and statements</p>
                  </div>
                  <div class="bg-gray-50 px-5 py-3">
                    <div class="text-sm">
                      <a href="#" class="font-medium text-green-600 hover:text-green-500">
                        View Reports
                      </a>
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <!-- Member Dashboard -->
            <div *ngIf="currentUser?.role === 'Member'" class="col-span-full">
              <h2 class="text-2xl font-bold text-gray-900 mb-4">Member Dashboard</h2>
              
              <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
                <div class="bg-white overflow-hidden shadow rounded-lg">
                  <div class="p-5">
                    <h3 class="text-lg font-medium text-gray-900">My Profile</h3>
                    <p class="text-sm text-gray-500 mt-1">View and manage your profile information</p>
                  </div>
                  <div class="bg-gray-50 px-5 py-3">
                    <div class="text-sm">
                      <a href="#" class="font-medium text-blue-600 hover:text-blue-500">
                        View Profile
                      </a>
                    </div>
                  </div>
                </div>

                <div class="bg-white overflow-hidden shadow rounded-lg">
                  <div class="p-5">
                    <h3 class="text-lg font-medium text-gray-900">Loan History</h3>
                    <p class="text-sm text-gray-500 mt-1">View your loan history and current status</p>
                  </div>
                  <div class="bg-gray-50 px-5 py-3">
                    <div class="text-sm">
                      <a href="#" class="font-medium text-green-600 hover:text-green-500">
                        View Loans
                      </a>
                    </div>
                  </div>
                </div>

                <div class="bg-white overflow-hidden shadow rounded-lg">
                  <div class="p-5">
                    <h3 class="text-lg font-medium text-gray-900">Savings Summary</h3>
                    <p class="text-sm text-gray-500 mt-1">View your savings and share information</p>
                  </div>
                  <div class="bg-gray-50 px-5 py-3">
                    <div class="text-sm">
                      <a href="#" class="font-medium text-yellow-600 hover:text-yellow-500">
                        View Savings
                      </a>
                    </div>
                  </div>
                </div>
              </div>
            </div>

          </div>
        </div>
      </div>
    </div>
  `
})
export class DashboardComponent implements OnInit {
  currentUser: UserInfo | null = null;
  stats = {
    totalSocieties: 0,
    totalUsers: 0,
    totalMembers: 0,
    activeLoans: 0,
    societyMembers: 0,
    societyLoans: 0,
    pendingApprovals: 0
  };

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    this.currentUser = this.authService.getCurrentUser();
    this.loadDashboardStats();
  }

  logout(): void {
    this.authService.logout();
  }

  private loadDashboardStats(): void {
    // Mock data - replace with actual API calls
    this.stats = {
      totalSocieties: 5,
      totalUsers: 25,
      totalMembers: 150,
      activeLoans: 85,
      societyMembers: 30,
      societyLoans: 15,
      pendingApprovals: 3
    };
  }
}
