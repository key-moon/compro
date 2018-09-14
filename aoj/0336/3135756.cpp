// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/0336/judge/3135756/C++
#include <iostream>
using namespace std;

int main() {
	long long h,r;
	cin >> h >> r;
	cout << (h + r == 0 ? 0 : (h + r > 0 ? 1 : -1)) << endl;
	return 0;
}
