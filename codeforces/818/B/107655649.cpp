// detail: https://codeforces.com/contest/818/submission/107655649
#include <bits/stdc++.h>
#define var auto
using ll = long long;
const char newl = '\n';
template <typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template <typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

using namespace std;

int main() {
  int n, m;
  cin >> n >> m;
  vector<bool> used(n + 1);
  used[0] = true;
  vector<int> res(n);
  int last;
  cin >> last;
  last--;
  for (int i = 1; i < m; i++) {
    int l;
    cin >> l;
    l--;
    var distance = (l + n - last) % n;
    if (distance == 0) distance += n;
    if (res[last] == 0) {
      if (used[distance]) {
        cout << -1 << endl;
        return 0;
      }
      used[distance] = true;
      res[last] = distance;
    }
    else {
      if (res[last] != distance) {
        cout << -1 << endl;
        return 0;
      }
    }
    last = l;
  }
  int j = 0;
  for (int i = 0; i < n; i++) {
    if (!res[i]) {
      while (used[j]) j++;
      res[i] = j;
      used[j] = true;
    }
    if (i != 0) cout << " ";
    cout << res[i];
  }
  cout << endl;
}
