// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2946/judge/6005474/C++17
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }


ll solve(int y, int x) {
  y = abs(y);
  x = abs(x);
  if (y % 2 == 1 && x % 2 == 1) {
    return y + x - 1;
  }
  if (y % 2 == 0 && x % 2 == 0) {
    return y + x;
  }
  if (x % 2 == 1) swap(y, x);
  assert(y % 2 == 1);
  assert(x % 2 == 0);
  if (x == 0) {
    if (y == 1) return 1;
    return y + 1;
  }
  return y + x;
}

bool solve() {
  int y, x;
  if (scanf("%d %d", &y, &x) == -1) return false;

  var res = solve(y, x);

  cout << res << endl;
  return true;
}

int main() {
  /*for (int i = -10; i <= 10; i++) {
    cout << "[+] i = " << i << endl;
    for (int j = -10; j <= 10; j++) {
      if ((solve(i, j) != naive(i, j))) {
        cout << i << " " << j << endl;
      }
    }
  }*/
  ios::sync_with_stdio(false);
  cin.tie(nullptr);
  while (solve());
}


