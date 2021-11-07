// detail: https://atcoder.jp/contests/abc226/submissions/27118525
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }



/*
 * Algorithm : Simplex ( Linear Programming )
 * Author : Simon Lo
 * Note: Simplex algorithm on augmented matrix a of dimension (m+1)x(n+1)
 * returns 1 if feasible, 0 if not feasible, -1 if unbounded
 * returns solution in b[] in original var order, max(f) in ret
 * form: maximize sum_j(a_mj*x_j)-a_mn s.t. sum_j(a_ij*x_j)<=a_in
 * in standard form.
 * To convert into standard form:
 * 1. if exists equality constraint, then replace by both >= and <=
 * 2. if variable x doesn't have nonnegativity constraint, then replace by
 * difference of 2 variables like x1-x2, where x1>=0, x2>=0
 * 3. for a>=b constraints, convert to -a<=-b
 * note: watch out for -0.0 in the solution, algorithm may cycle
 * EPS = 1e-7 may give wrong answer, 1e-10 is better
 */

// Caution: long double can give TLE
typedef long double ld;
typedef vector<ld> vd;
typedef vector<vd> vvd;

const ld EPS = 1e-3;

struct LPSolver {
  int m, n;
  vector<int> B, N;
  vvd D;

  LPSolver(const vvd& A, const vd& b, const vd& c) :
    m(b.size()), n(c.size()), N(n + 1), B(m), D(m + 2, vd(n + 2)) {
    for (int i = 0; i < m; i++) for (int j = 0; j < n; j++) D[i][j] = A[i][j];
    for (int i = 0; i < m; i++) { B[i] = n + i; D[i][n] = -1; D[i][n + 1] = b[i]; }
    for (int j = 0; j < n; j++) { N[j] = j; D[m][j] = -c[j]; }
    N[n] = -1; D[m + 1][n] = 1;
  }

  void Pivot(int r, int s) {
    ld inv = 1.0 / D[r][s];
    for (int i = 0; i < m + 2; i++) if (i != r)
      for (int j = 0; j < n + 2; j++) if (j != s)
        D[i][j] -= D[r][j] * D[i][s] * inv;
    for (int j = 0; j < n + 2; j++) if (j != s) D[r][j] *= inv;
    for (int i = 0; i < m + 2; i++) if (i != r) D[i][s] *= -inv;
    D[r][s] = inv;
    swap(B[r], N[s]);
  }

  bool Simplex(int phase) {
    int x = phase == 1 ? m + 1 : m;
    while (true) {
      int s = -1;
      for (int j = 0; j <= n; j++) {
        if (phase == 2 && N[j] == -1) continue;
        if (s == -1 || D[x][j] < D[x][s] || D[x][j] == D[x][s] && N[j] < N[s]) s = j;
      }
      if (D[x][s] > -EPS) return true;
      int r = -1;
      for (int i = 0; i < m; i++) {
        if (D[i][s] < EPS) continue;
        if (r == -1 || D[i][n + 1] / D[i][s] < D[r][n + 1] / D[r][s] ||
          (D[i][n + 1] / D[i][s]) == (D[r][n + 1] / D[r][s]) && B[i] < B[r]) r = i;
      }
      if (r == -1) return false;
      Pivot(r, s);
    }
  }

  bool Feasable(vd& x) {
    int r = 0;
    for (int i = 1; i < m; i++) if (D[i][n + 1] < D[r][n + 1]) r = i;
    if (D[r][n + 1] < -EPS) {
      Pivot(r, n);
      if (!Simplex(1) || D[m + 1][n + 1] < -EPS) return false;
    }
    return true;
  }

  ld Solve(vd& x) {
    int r = 0;
    for (int i = 1; i < m; i++) if (D[i][n + 1] < D[r][n + 1]) r = i;
    if (D[r][n + 1] < -EPS) {
      Pivot(r, n);
      if (!Simplex(1) || D[m + 1][n + 1] < -EPS) return -numeric_limits<ld>::infinity();
      for (int i = 0; i < m; i++) if (B[i] == -1) {
        int s = -1;
        for (int j = 0; j <= n; j++)
          if (s == -1 || D[i][j] < D[i][s] || D[i][j] == D[i][s] && N[j] < N[s]) s = j;
        Pivot(i, s);
      }
    }
    if (!Simplex(2)) return numeric_limits<ld>::infinity();
    x = vd(n);
    for (int i = 0; i < m; i++) if (B[i] < n) x[B[i]] = D[i][n + 1];
    return D[m][n + 1];
  }
};

/* Equations are of the matrix form Ax<=b, and we want to maximize
the function c. We are given coeffs of A, b and c. In case of minimizing,
we negate the coeffs of c and maximize it. Then the negative of returned
'value' is the answer.
All the constraints should be in <= form. So we may need to negate the
coeffs.
*/


void solve() {
  vector<vector<ld>> A(10, vector<ld>(18));
  vector<ld> B(10);
  vector<ll> a(5);
  vector<ll> b(5);
  for (int i = 0; i < 5; i++) {
    cin >> a[i];
    B[i + 5] = -a[i];
  }
  for (int i = 0; i < 5; i++) {
    cin >> b[i];
    B[i] = b[i];
  }
  A[0][0] = 1;   // 1
  A[5][0] = -1;  // 1

  A[1][1] = 1;   // 0 1
  A[6][1] = -1;  //   1
  A[1][2] = 1;   // 2 0
  A[5][2] = -2;  // 2

  A[2][3] = 1;   // 0 0 1
  A[7][3] = -1;  //     1
  A[2][4] = 1;   // 1 1 0
  A[5][4] = -1;  // 1
  A[6][4] = -1;  //   1
  A[2][5] = 1;   // 3 0 0
  A[5][5] = -3;  // 3

  A[3][6] = 1;   // 0 0 0 1
  A[8][6] = -1;  //       1
  A[3][7] = 1;   // 1 0 1 0
  A[5][7] = -1;  // 1
  A[7][7] = -1;  //     1
  A[3][8] = 1;   // 0 2 0 0
  A[6][8] = -2;  //   2
  A[3][9] = 1;   // 2 1 0 0
  A[5][9] = -2;  // 2
  A[6][9] = -1;  //   1
  A[3][10] = 1;  // 4 0 0 0
  A[5][10] = -4; // 4

  A[4][11] = 1;  // 0 0 0 0 1
  A[9][11] = -1; //         1
  A[4][12] = 1;  // 1 0 0 1 0
  A[5][12] = -1; // 1
  A[8][12] = -1; //       1
  A[4][13] = 1;  // 0 1 1 0 0
  A[6][13] = -1; //   1
  A[7][13] = -1; //     1
  A[4][14] = 1;  // 2 0 1 0 0
  A[5][14] = -2; // 2
  A[7][14] = -1; //     1
  A[4][15] = 1;  // 1 2 0 0 0
  A[5][15] = -1; // 1
  A[6][15] = -2; //   2
  A[4][16] = 1;  // 3 1 0 0 0
  A[5][16] = -3; // 3
  A[6][16] = -1; //   1
  A[4][17] = 1;  // 5 0 0 0 0
  A[5][17] = -5; // 5

  for (int i = 0; i < 18; i++) {
    var cnt = 1;
    while (A[cnt - 1][i] == 0) cnt++;
    for (int j = 0; j < 5; j++) {
      cnt += A[5 + j][i] * (j + 1);
    }
    if (cnt != 0) {
      assert(false);
    }
  }

  vector<ld> C(18, 1);
  LPSolver sol(A, B, C);
  vd x;
  var s = sol.Solve(x);
  cout << (s != -numeric_limits<ld>::infinity() ? "Yes" : "No") << endl;
}

int main() {
  ios::sync_with_stdio(false);
  cin.tie(nullptr);
  int t;
  cin >> t;
  for (int i = 0; i < t; i++) {
    solve();
  }
}