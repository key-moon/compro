// detail: https://atcoder.jp/contests/abc134/submissions/20436626
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n;
  cin >> n;
  vector<int> a(n);
  int mx1 = INT_MIN;
  int mx2 = INT_MIN;
  for (int i = 0; i < n; i++) {
    cin >> a[i];
    if (mx1 <= a[i]) {
      mx2 = mx1;
      mx1 = a[i];
    }
    else if (mx2 <= a[i]) {
      mx2 = a[i];
    }
  }
  for (var&& i : a) {
    if (i == mx1) {
      cout << mx2 << endl;
    }
    else {
      cout << mx1 << endl;
    }
  }
}
