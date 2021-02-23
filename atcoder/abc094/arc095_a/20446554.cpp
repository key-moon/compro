// detail: https://atcoder.jp/contests/abc094/submissions/20446554
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
  vector<int> v(n);
  for (int i = 0; i < n; i++) {
    cin >> v[i];
  }
  var vv = v;
  sort(vv.begin(), vv.end());
  var elem1 = vv[n / 2 - 1];
  var elem2 = vv[n / 2];
  for (var&& elem : v) {
    if (elem <= elem1) cout << elem2;
    else cout << elem1;
    cout << endl;
  }
}
