#include<bits/stdc++.h>

using ll = long long;
#define var auto

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

void solve() {
  ll w, g, h, r;
  cin >> w >> g >> h >> r;
  double mn = sqrt((h - g) * (h - g) + w * w);
  double mx = sqrt(w * w + (g + h - r - r) * (g + h - r - r));
  cout << mn << ' ' << mx << endl;
}

int main() {
  cout << setprecision(15);
  int t;
  cin >> t;
  for (int i = 0; i < t; i++) {
    solve();
  }
}
