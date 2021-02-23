// detail: https://atcoder.jp/contests/abc141/submissions/20436464
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n, k, q;
  cin >> n >> k >> q;
  vector<int> res(n, k - q);
  for (int i = 0; i < q; i++) {
    int a;
    cin >> a;
    res[a - 1]++;
  }
  for (int i = 0; i < n; i++) {
    if (res[i] <= 0) cout << "No" << endl;
    else cout << "Yes" << endl;
  }

}
