// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1610/judge/4895892/C++14
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template< typename T1, typename T2 > void chmin(T1 &a, T2 b) { if (a > b) a = b; }
template< typename T1, typename T2 > void chmax(T1 &a, T2 b) { if (a < b) a = b; }

signed main() {
  while (1){
    int n, m;
    cin >> m >> n;
    if (n == 0) break;
    vector<bool> p(7368800, false);
    int count = 0;
    int i = m;
    while (1){
      if (!p[i]){
	if (count >= n){
	  cout << i << endl;
	  goto end;
	}
	for (int j = i; j < (int)p.size(); j += i){
	  p[j] = true;
	}
	//cout << i << endl;
	count++;
      }
      i++;
    }
  end:;
  }
}

