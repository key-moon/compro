// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1608/judge/4895890/C++14
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template< typename T1, typename T2 > void chmin(T1 &a, T2 b) { if (a > b) a = b; }
template< typename T1, typename T2 > void chmax(T1 &a, T2 b) { if (a < b) a = b; }

signed main() {
  while(1){
  int n;
  cin >> n;
  if (n == 0) break;
  vector<int> a(n);
  for (int i = 0; i < n; i++){
    cin >> a[i];
  }
  int mi = 2147483647;
  sort(a.begin(), a.end());
  for (int i = 0; i < n - 1; i++){
    chmin(mi, abs(a[i] - a[i + 1]));
  }
  cout << mi << endl;
  }
}

